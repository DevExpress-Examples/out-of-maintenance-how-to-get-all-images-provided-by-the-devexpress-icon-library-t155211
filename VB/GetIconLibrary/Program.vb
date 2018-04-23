Imports System
Imports System.IO
Imports DevExpress.Images

Namespace GetIconLibrary

    Friend Class Program
        Shared Sub Main(ByVal args() As String)

            Dim filePath As String = "c:\DevExpressIcons\"

            If Not Directory.Exists(filePath) Then
                Try
                    Directory.CreateDirectory(filePath)
                Catch e As Exception
                    Console.WriteLine("Can't create a directory: {0}", e.ToString())
                Finally
                End Try
            End If


            For Each imageInfo As ImagesAssemblyImageInfo In ImagesAssemblyImageList.Images
                If imageInfo.Colored Then
                    Using str As Stream = ImageResourceCache.Default.GetResourceByFileName(imageInfo.Name)
                        If str IsNot Nothing Then
                            Using fileStream As FileStream = File.Create(filePath & imageInfo.Name)
                                str.CopyTo(fileStream)
                                Console.WriteLine("Writing " & imageInfo.Name)
                            End Using
                        End If
                    End Using
                End If
            Next imageInfo

        End Sub
    End Class

End Namespace
