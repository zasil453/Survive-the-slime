Public Class Form1
    Dim r As New Random
    'highscore 489
    Sub randmove(p As PictureBox)
        Dim x As Integer
        Dim y As Integer
        x = r.Next(-25, 26)
        y = r.Next(-25, 26)
        MoveTo(p, x, y)
    End Sub
    Dim count As Integer
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.K

            Case Keys.W
                MoveTo(PictureBox1, 0, -30)
            Case Keys.S
                MoveTo(PictureBox1, 0, 30)
            Case Keys.A
                MoveTo(PictureBox1, -30, 0)
            Case Keys.D
                MoveTo(PictureBox1, 30, 0)
            Case Keys.R
                PictureBox2.BackColor = Color.Green
                win.Visible = True
                Timer1.Enabled = False
                Timer2.Enabled = False
                Timer3.Enabled = False
                Timer4.Enabled = False
                Timer5.Enabled = False
                Timer6.Enabled = False
                Timer6.Enabled = False
                Timer7.Enabled = False
                Timer8.Enabled = False
                Timer9.Enabled = False
                Timer10.Enabled = False
                Timer11.Enabled = False
                Timer12.Enabled = False
                Timer13.Enabled = False
                Timer14.Enabled = False
                Timer15.Enabled = False
                Timer16.Enabled = False
            Case Keys.Tab

        End Select

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        chase(slime)
    End Sub
    Sub move(p As PictureBox, x As Integer, y As Integer)
        p.Location = New Point(p.Location.X + x, p.Location.Y + y)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
    Sub follow(p As PictureBox)
        Static headstart As Integer
        Static c As New Collection
        c.Add(PictureBox1.Location)
        headstart = headstart + 1
        If headstart > 10 Then
            p.Location = c.Item(1)
            c.Remove(1)
        End If
    End Sub

    Public Sub chase(p As PictureBox)
        Dim x, y As Integer
        If p.Location.X > PictureBox1.Location.X Then
            x = -10
        Else
            x = 10
        End If
        MoveTo(p, x, 0)
        If p.Location.Y < PictureBox1.Location.Y Then
            y = 10
        Else
            y = -10
        End If
        MoveTo(p, x, y)
    End Sub





    Function Collision(p As PictureBox, t As String, Optional ByRef other As Object = vbNull)
        Dim col As Boolean

        For Each c In Controls
            Dim obj As Control
            obj = c
            If obj.Visible AndAlso p.Bounds.IntersectsWith(obj.Bounds) And obj.Name.ToUpper.Contains(t.ToUpper) Then
                col = True
                other = obj
            End If
        Next
        Return col
    End Function
    'Return true or false if moving to the new location is clear of objects ending with t
    Function IsClear(p As PictureBox, distx As Integer, disty As Integer, t As String) As Boolean
        Dim b As Boolean

        p.Location += New Point(distx, disty)
        b = Not Collision(p, t)
        p.Location -= New Point(distx, disty)
        Return b
    End Function
    'Moves and object (won't move onto objects containing  "wall" and shows green if object ends with "win"
    Sub MoveTo(p As PictureBox, distx As Integer, disty As Integer)
        If IsClear(p, distx, disty, "WALL") Then
            p.Location += New Point(distx, disty)
        End If
        Dim other As Object = Nothing
        If p.Name = "PictureBox1" And Collision(p, "WIN", other) Then
            Me.BackColor = Color.Green
            other.visible = False
        End If

        If p.Name = "PictureBox1" And Collision(p, "slime") Then
            PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipX)
            Me.Refresh()
            PictureBox2.BackColor = Color.Red
            lose.Visible = True
            Timer1.Enabled = False
            Timer2.Enabled = False
            Timer3.Enabled = False
            Timer4.Enabled = False
            Timer5.Enabled = False
            Timer6.Enabled = False
            Timer6.Enabled = False
            Timer7.Enabled = False
            Timer8.Enabled = False
            Timer9.Enabled = False
            Timer10.Enabled = False
            Timer11.Enabled = False
            Timer12.Enabled = False
            Timer13.Enabled = False
            Timer14.Enabled = False
            Timer15.Enabled = False
            Timer16.Enabled = False
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        chase(slime1)
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        chase(slime2)
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        chase(slime3)
    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        chase(slime4)
    End Sub

    Private Sub Timer6_Tick(sender As Object, e As EventArgs) Handles Timer6.Tick
        chase(slime5)
    End Sub

    Private Sub Timer7_Tick(sender As Object, e As EventArgs) Handles Timer7.Tick
        slime6.Visible = True
        Timer8.Enabled = True
    End Sub

    Private Sub Timer8_Tick(sender As Object, e As EventArgs) Handles Timer8.Tick
        chase(slime6)
    End Sub

    Private Sub Timer9_Tick(sender As Object, e As EventArgs) Handles Timer9.Tick
        slime7.Visible = True
        Timer10.Enabled = True
    End Sub

    Private Sub Timer10_Tick(sender As Object, e As EventArgs) Handles Timer10.Tick
        chase(slime7)
    End Sub

    Private Sub Timer11_Tick(sender As Object, e As EventArgs) Handles Timer11.Tick
        slime8.Visible = True
        Timer12.Enabled = True
    End Sub

    Private Sub Timer12_Tick(sender As Object, e As EventArgs) Handles Timer12.Tick
        chase(slime8)
    End Sub

    Private Sub Timer13_Tick(sender As Object, e As EventArgs) Handles Timer13.Tick
        slime9.Visible = True
        Timer14.Enabled = True
    End Sub

    Private Sub Timer14_Tick(sender As Object, e As EventArgs) Handles Timer14.Tick
        chase(slime9)
    End Sub

    Private Sub Timer15_Tick(sender As Object, e As EventArgs) Handles Timer15.Tick
        count = count + 1
        Label1.Text = count
    End Sub

    Private Sub Timer16_Tick(sender As Object, e As EventArgs) Handles Timer16.Tick
        randmove(Slime10)
    End Sub
End Class