
Imports System.IO
Imports System.Reflection.Emit
Imports System.Runtime.Serialization.Formatters
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Header
Imports TagLib.Asf
Imports WMPLib, TagLib, System.Reflection

Public Class Form1

    Public Class Song
        Public Property FilePath As String
        Public Property Name As String
        Public Property Artist As String
        Public Property Album As String
        Public Property Length As TimeSpan
        Public Property dblLength As Double
        Public Property Index As Integer

        Public Sub New(filePath As String, name As String, artist As String, album As String, length As TimeSpan, dblLength As Double, myIndex As Integer)
            Me.FilePath = filePath
            Me.Name = name
            Me.Artist = artist
            Me.Album = album
            Me.Length = length
            Me.dblLength = dblLength
            Me.Index = myIndex
        End Sub

    End Class

    Public Property SongPlayedPaused As Boolean
        Get
            Return songPlaying
        End Get

        Set(value As Boolean)
            If value <> songPlaying Then
                songPlaying = value
                If songPlaying = False Then
                    btnPlay.Text = "Play"
                Else
                    btnPlay.Text = "Pause"
                End If


            End If
        End Set
    End Property



    ' -------------------------- Globals ------------------------------------------

    Public Event ItemAddedToListBox(theListBox As ListBox)

    Dim milliseconds As Integer
    Dim WithEvents timer As New Timer
    Private firstSongPlayed As Boolean
    Private currentSong As Song
    Private songPosition As Double
    Private songPlaying As Boolean
    Private songList As New List(Of Song)
    Private mp3Play As WindowsMediaPlayer = New WindowsMediaPlayer

    ' -------------------------- End Globals ------------------------------------------

    ' ------------------------------------ Handlers -----------------------------------------------------

    Private Sub ListBoxItemAddedHandler(theListBox As ListBox) Handles Me.ItemAddedToListBox
        If (theListBox.Items).Count <> 0 Then
            lblNoMusic.Visible = False
        Else
            lblNoMusic.Visible = True
        End If
    End Sub

    Private Sub lstMusic_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMusic.SelectedIndexChanged
        If lstMusic.SelectedIndex > -1 Then
            Dim currentItem As Song

            currentItem = songList(lstMusic.SelectedIndex)
            rtbInfo.Visible = True

            Dim rtfText As String

            rtfText += ($" \b Song\b0: {currentItem.Name}\par")
            rtfText += ($" \b Artist\b0: {currentItem.Artist}\par")
            rtfText += ($" \b Album\b0: {currentItem.Name}\par")
            rtfText += ($" \b Length\b0: {currentItem.Length.ToString}\par")

            rtbInfo.Rtf = ConvertToRTF(rtfText)

            If firstSongPlayed = True Then
                If lstMusic.SelectedIndex <> currentSong.Index Then
                    btnSwitchSong.Visible = True
                Else
                    btnSwitchSong.Visible = False
                End If
            End If




        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rtbInfo.Visible = False
        btnSwitchSong.Visible = False

    End Sub

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click


        If lstMusic.SelectedIndex > -1 Then

            If lstMusic.Items.Count = 1 And lstMusic.SelectedIndex = 0 And firstSongPlayed = False Then
                firstSongPlayed = True
                mp3Play.URL = songList(lstMusic.SelectedIndex).FilePath
                mp3Play.controls.stop()
                initializeProgressBar(songList(lstMusic.SelectedIndex))
            End If

            If btnPlay.Text = "Pause" Then
                mp3Play.controls.pause()
                Me.SongPlayedPaused = False
                songPosition = mp3Play.controls.currentPosition
            Else
                If mp3Play.URL = songList(lstMusic.SelectedIndex).FilePath Then
                    currentSong = songList(lstMusic.SelectedIndex)
                    lblCurrentSong.Text = currentSong.Name

                End If
                mp3Play.controls.play()
                Me.SongPlayedPaused = True
                mp3Play.controls.currentPosition = songPosition
            End If
        Else
            MsgBox("No song is selected!")
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Filter = "MP3 Files (*.mp3)|*.mp3|All Files (*.*)|*.*"
        openFileDialog.Title = "Select an MP3 File"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            updateMusic(openFileDialog)
        End If
    End Sub

    Private Sub btnSwitchSong_Click(sender As Object, e As EventArgs) Handles btnSwitchSong.Click
        mp3Play.URL = songList(lstMusic.SelectedIndex).FilePath
        mp3Play.controls.stop()
        Me.SongPlayedPaused = False

        initializeProgressBar(songList(lstMusic.SelectedIndex))

        btnSwitchSong.Visible = False
    End Sub


    ' ------------------------------------ End Handlers -----------------------------------------------------

    ' ----------------------------------------- Functions/Subs ----------------------------------------------------- 

    Private Function ConvertToRTF(ByVal message As String) As String
        Dim rtfText As String = "{\rtf1\ansi\deff0{\fonttbl{\f0 Arial;}}"
        rtfText &= "\viewkind4\uc1\pard\lang1033\f0\fs20" & message & "\par}"
        Return rtfText
    End Function

    Private Sub updateMusic(openFileDialog As OpenFileDialog)
        Dim filePath As String = openFileDialog.FileName

        songList.Add(makeSong(openFileDialog))

        lstMusic.Items.Clear()
        For Each song As Song In songList
            If Not String.IsNullOrEmpty(song.Artist) Then
                lstMusic.Items.Add($"{song.Name} - {song.Artist}")
            Else
                lstMusic.Items.Add($"{song.Name}")
            End If
        Next

        RaiseEvent ItemAddedToListBox(lstMusic)
    End Sub

    Private Function makeSong(openFileDialog As OpenFileDialog)
        Static songsAdded As Integer = -1
        songsAdded += 1
        Dim filePath As String = openFileDialog.FileName
        Dim currentSong As TagLib.File = TagLib.File.Create(filePath)

        Dim title As String

        If Not (String.IsNullOrEmpty(currentSong.Tag.Title)) Then
            title = currentSong.Tag.Title
        Else
            title = filePath.Substring(filePath.LastIndexOf("\") + 1)
            title = title.Substring(0, title.Length - 4)
        End If

        Dim artist As String = currentSong.Tag.FirstPerformer
        Dim album As String = currentSong.Tag.Album
        Dim length As TimeSpan = currentSong.Properties.Duration

        Debug.Print($"Title: {title}, Artist: {artist}, Album: {album}, Length: {length}")


        Dim newSong As New Song(filePath, title, artist, album, length, length.TotalSeconds, songsAdded)
        currentSong.Dispose()

        Return newSong
    End Function

    Private Sub initializeProgressBar(currentSong As Song)

        prbSongProgress.Maximum = CInt(currentSong.dblLength)
        prbSongProgress.Step = 1

        Debug.Print($"Song Length = {CInt(currentSong.dblLength)}, Maximum = {prbSongProgress.Maximum}, Step = {prbSongProgress.Step}, Width = {prbSongProgress.Width}")

        timer.Stop()
        milliseconds = 0
        timer.Start()

    End Sub

    Private Sub Timer_Tick(sender As System.Object, e As System.EventArgs) Handles timer.Tick
        prbSongProgress.Value = mp3Play.controls.currentPosition

        If prbSongProgress.Value >= prbSongProgress.Maximum Then
            timer.Stop()
        End If

    End Sub

    Private Sub prbSongProgress_Click(sender As Object, e As EventArgs) Handles prbSongProgress.Click
        Dim clickPosition As Integer = prbSongProgress.PointToClient(MousePosition).X
        Dim value As Integer = CInt((clickPosition / prbSongProgress.Width) * prbSongProgress.Maximum)

        prbSongProgress.Value = value
        mp3Play.controls.currentPosition = value
    End Sub




    ' ----------------------------------------- End Functions/Subs ----------------------------------------------------- 

End Class
