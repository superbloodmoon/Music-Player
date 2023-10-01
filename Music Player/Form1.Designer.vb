<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.lstMusic = New System.Windows.Forms.ListBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.prbSongProgress = New System.Windows.Forms.ProgressBar()
        Me.lblNoMusic = New System.Windows.Forms.Label()
        Me.rtbInfo = New System.Windows.Forms.RichTextBox()
        Me.btnSwitchSong = New System.Windows.Forms.Button()
        Me.lblCurrentSong = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnPlay
        '
        Me.btnPlay.Location = New System.Drawing.Point(393, 35)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(130, 39)
        Me.btnPlay.TabIndex = 0
        Me.btnPlay.Text = "Play"
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'lstMusic
        '
        Me.lstMusic.FormattingEnabled = True
        Me.lstMusic.ItemHeight = 18
        Me.lstMusic.Location = New System.Drawing.Point(118, 35)
        Me.lstMusic.Name = "lstMusic"
        Me.lstMusic.Size = New System.Drawing.Size(134, 202)
        Me.lstMusic.TabIndex = 2
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(14, 35)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(81, 61)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "&Add Track"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'prbSongProgress
        '
        Me.prbSongProgress.Location = New System.Drawing.Point(278, 212)
        Me.prbSongProgress.Name = "prbSongProgress"
        Me.prbSongProgress.Size = New System.Drawing.Size(244, 26)
        Me.prbSongProgress.TabIndex = 4
        '
        'lblNoMusic
        '
        Me.lblNoMusic.AutoSize = True
        Me.lblNoMusic.BackColor = System.Drawing.SystemColors.Window
        Me.lblNoMusic.Location = New System.Drawing.Point(147, 127)
        Me.lblNoMusic.Name = "lblNoMusic"
        Me.lblNoMusic.Size = New System.Drawing.Size(76, 18)
        Me.lblNoMusic.TabIndex = 5
        Me.lblNoMusic.Text = "No music."
        '
        'rtbInfo
        '
        Me.rtbInfo.BackColor = System.Drawing.SystemColors.Control
        Me.rtbInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbInfo.Location = New System.Drawing.Point(267, 35)
        Me.rtbInfo.Name = "rtbInfo"
        Me.rtbInfo.Size = New System.Drawing.Size(100, 150)
        Me.rtbInfo.TabIndex = 6
        Me.rtbInfo.Text = ""
        '
        'btnSwitchSong
        '
        Me.btnSwitchSong.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSwitchSong.Location = New System.Drawing.Point(393, 81)
        Me.btnSwitchSong.Name = "btnSwitchSong"
        Me.btnSwitchSong.Size = New System.Drawing.Size(132, 26)
        Me.btnSwitchSong.TabIndex = 7
        Me.btnSwitchSong.Text = "Switch Song"
        Me.btnSwitchSong.UseVisualStyleBackColor = True
        '
        'lblCurrentSong
        '
        Me.lblCurrentSong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCurrentSong.Location = New System.Drawing.Point(278, 255)
        Me.lblCurrentSong.Name = "lblCurrentSong"
        Me.lblCurrentSong.Size = New System.Drawing.Size(244, 18)
        Me.lblCurrentSong.TabIndex = 8
        Me.lblCurrentSong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(537, 282)
        Me.Controls.Add(Me.lblCurrentSong)
        Me.Controls.Add(Me.btnSwitchSong)
        Me.Controls.Add(Me.rtbInfo)
        Me.Controls.Add(Me.lblNoMusic)
        Me.Controls.Add(Me.prbSongProgress)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lstMusic)
        Me.Controls.Add(Me.btnPlay)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Form1"
        Me.Text = "Custom Media Player"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnPlay As Button
    Friend WithEvents lstMusic As ListBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents prbSongProgress As ProgressBar
    Friend WithEvents lblNoMusic As Label
    Friend WithEvents rtbInfo As RichTextBox
    Friend WithEvents btnSwitchSong As Button
    Friend WithEvents lblCurrentSong As Label
End Class
