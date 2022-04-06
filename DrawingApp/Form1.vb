Public Class Form1
    Private m_Previous As System.Nullable(Of Point) = Nothing
    Dim m_shapes As New Collection
    Dim c As Color
    Dim w As Integer
    Dim type As String



    Private Sub pictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        m_Previous = e.Location
        pictureBox1_MouseMove(sender, e)
    End Sub

    Private Sub pictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove

        Dim d As Object
        If m_Previous IsNot Nothing Then
            If type = "Line" Then
                d = New Line(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, w)
            End If
            If type = "rectangle" Then
                d = New Square(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, w)
                d.w = TrackBar2.Value
                d.h = TrackBar3.Value
            End If
            If type = "polygon" Then
                d = New Polygon(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, w)
                d.w = TrackBar2.Value
                d.h = TrackBar3.Value
            End If
            If type = "Ngon" Then
                d = New Ngon(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, w)
                d.radius = TrackBar3.Value
                d.Sides = TrackBar4.Value
            End If
            If type = "Picture" Then
                d = New PBox(PictureBox1.Image, m_Previous, e.Location)
                d.w = TrackBar1.Value
                d.h = TrackBar1.Value

                d.picture = PictureBox2.Image
            End If
        End If

        m_shapes.Add(d)
            PictureBox1.Invalidate()
        m_Previous = e.Location
    End Sub

    Private Sub pictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        m_Previous = Nothing
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        If PictureBox1.Image Is Nothing Then
            Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.Clear(Color.White)
            End Using
            PictureBox1.Image = bmp
        End If

    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        For Each s As Object In m_shapes
            s.Draw()
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ColorDialog1.ShowDialog()
        Button1.BackColor = ColorDialog1.Color
        c = Button1.BackColor

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        c = sender.backcolor

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        c = sender.backcolor
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        SaveFileDialog1.ShowDialog()
        PictureBox1.Image.Save(SaveFileDialog1.FileName)
    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll

    End Sub

    Private Sub Square1_Click(sender As Object, e As EventArgs) Handles Square1.Click
        type = "Line"
    End Sub

    Private Sub Rect1_Click(sender As Object, e As EventArgs) Handles Rect1.Click
        type = "rectangle"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        type = "polygon"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        type = "Ngon"
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        type = "Picture"
    End Sub
End Class
