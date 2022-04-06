Public Class Ngon
    Public Property Pen As Pen
    Public Property sides As Integer
    Public Property radius As Integer
    Public Property w As Integer
    Public Property h As Integer
    Dim m_image As Image
    Dim m_a As Point
    Dim m_b As Point

    Public Sub New(i As Image, a As Point, b As Point)
        Pen = Pens.Red
        m_image = i
        m_a = a
        m_b = b
    End Sub
    Public Sub Draw()
        Dim points(sides - 1) As Point

        For index = 0 To sides - 1
            Dim X As Integer
            Dim Y As Integer

            X = Math.Cos(index * 2 * Math.PI / sides) * radius
            Y = Math.Sin(index * 2 * Math.PI / sides) * radius
            points(index) = New Point(m_a.X + X, m_a.Y + Y)
        Next


        Using g As Graphics = Graphics.FromImage(m_image)
            g.DrawPolygon(Pen, points)
        End Using

    End Sub
End Class
