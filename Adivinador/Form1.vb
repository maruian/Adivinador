Public Class Form1

    Dim aleatorio As Integer
    Dim contador As Integer


    Private Sub btnAleatorio_Click(sender As Object, e As EventArgs) Handles btnAleatorio.Click
        Randomize()
        ' El valor aleatorio debe estar entre uno y cien
        ' N = (Limsup - Liminf) * Rnd + Liminf
        aleatorio = CInt(Rnd() * 99) + 1
        contador = 1
        btnAleatorio.Enabled = False
        txtNumero.Enabled = True
    End Sub


    Private Sub txtNumero_KeyPress(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
        If e.KeyCode = Keys.Enter Then
            If IsNumeric(txtNumero.Text) Then
                If CInt(txtNumero.Text) > aleatorio Then
                    lbTecleados.Items.Add(txtNumero.Text & " Numero demasiado grande")
                    lbTecleados.TopIndex = lbTecleados.Items.Count - 1
                    contador = contador + 1
                ElseIf CInt(txtNumero.Text) < aleatorio Then
                    lbTecleados.Items.Add(txtNumero.Text & " Numero demasiado pequeño")
                    lbTecleados.TopIndex = lbTecleados.Items.Count - 1
                    contador = contador + 1
                Else
                    lbTecleados.Items.Add(txtNumero.Text & " FELICIDADES. Lo has encontrado")
                    lbTecleados.Items.Add("Intentos empleados: " & contador)
                    lbTecleados.TopIndex = lbTecleados.Items.Count - 1
                    txtNumero.Enabled = False
                End If
            Else
                MsgBox("Debes introducir un número!")
            End If
            txtNumero.Text = ""
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        btnAleatorio.Enabled = True
        txtNumero.Enabled = False
        lbTecleados.Items.Clear()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Application.Exit()
    End Sub

End Class
