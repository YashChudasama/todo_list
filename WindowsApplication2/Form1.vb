Public Class Form1
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If String.IsNullOrEmpty(ToolStripTextBox1.Text) Then
            MsgBox("Write your task before adding it to the Task List", vbCritical, "Empty TaskBox")
        Else
            'Add task in the Task List
            ListBox1.Items.Add(ToolStripTextBox1.Text.ToString)
            'Clear the task textbox
            ToolStripTextBox1.Clear()
            'Focus the task textbox
            ToolStripTextBox1.Focus()
            'Count Due Tasks in the Task List
            Label1.Text = "Due Tasks: " & ListBox1.Items.Count
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ActiveControl = ToolStripTextBox1.Control
        Label1.Text = "Due Tasks: " & ListBox1.Items.Count
    End Sub

    Private Sub ToolStripTextBox1_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox1.Click
        Dim selecteditemindex As Integer = ListBox1.Items.IndexOf(ListBox1.SelectedItem)
        Dim editaskinput As String
        Dim Item As Object = ListBox1.Items.Item(selecteditemindex)
        Dim index As Integer = ListBox1.Items.IndexOf(Item)
        editaskinput = InputBox("Edit the Task", "Edit selected Task")
        ListBox1.Items.Remove(ListBox1.SelectedItem)
        ListBox1.Items.Insert(index, editaskinput)

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        ListBox1.Items.Remove(ListBox1.SelectedItem)
        Label1.Text = "Due Tasks: " & ListBox1.Items.Count
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click


        Dim SaveFileDialog1 As New SaveFileDialog
        SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim sb As New System.Text.StringBuilder()
            For Each o As Object In ListBox1.Items
                sb.AppendLine(o)
            Next
            System.IO.File.WriteAllText(SaveFileDialog1.FileName, sb.ToString())
        End If

        'Dim SaveFile As New SaveFileDialog
        'SaveFileDialog1.FileName = ""
        'SaveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        'If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
        'My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, ListBox1.Items.ToString(), True)
        'End If

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim lines = (OpenFileDialog1.FileName)
            ListBox1.Items.Clear()
            ListBox1.Items.Add(lines)
        End If
    End Sub
End Class
