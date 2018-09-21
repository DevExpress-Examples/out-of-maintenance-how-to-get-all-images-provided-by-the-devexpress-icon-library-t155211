Imports System
Imports System.IO
Imports DevExpress.Images
Imports DevExpress.Utils.Design

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


            StoreImagesByImageType(filePath, ImageType.Colored)

        End Sub
        Public Shared Sub StoreImagesByImageType(ByVal filePath As String, ByVal imageType As ImageType)
            For Each imageInfo As ImagesAssemblyImageInfo In ImagesAssemblyImageList.Images
                Dim stream = ImageResourceCache.Default.GetResourceByFileName(imageInfo.Name, imageType)
                If stream Is Nothing Then
                    Continue For
                End If
                Using image As Image = System.Drawing.Image.FromStream(stream)
                    image.Save(filePath & imageInfo.Name)
                End Using
                Console.WriteLine("Writing " & imageInfo.Name)
            Next imageInfo
        End Sub
    End Class

End Namespace
