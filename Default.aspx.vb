Imports System.Data.SqlClient
Imports System.Data
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("testConnectionString").ConnectionString)
    Dim cmd As SqlCommand
    Dim ad As SqlDataAdapter
    Dim ds As New DataSet
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fpath, spath, tpath, fstore, sstore, tstore As String
        fpath = Server.MapPath("FImage/")
        fstore = "FImage/" + FileUpload1.FileName
        fpath = fpath + FileUpload1.FileName
        Label1.Text = "first Image will :" + fstore
        FileUpload1.SaveAs(fpath)

        spath = Server.MapPath("SImage/")
        sstore = "SImage/" + FileUpload2.FileName
        spath = spath + FileUpload2.FileName
        Label2.Text = "Second Image will :" + sstore
        FileUpload2.SaveAs(spath)


        tpath = Server.MapPath("TImage/")
        tstore = "TImage/" + FileUpload3.FileName
        tpath = tpath + FileUpload3.FileName
        Label3.Text = "Third Image will :" + tstore
        FileUpload3.SaveAs(tpath)


        cmd = New SqlCommand("insert into getImag values(@fimage,@simage,@timage)", con)
        cmd.Parameters.AddWithValue("@fimage", fstore)
        cmd.Parameters.AddWithValue("@simage", sstore)
        cmd.Parameters.AddWithValue("@timage", tstore)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        bind()
        Response.Write("record Inserted..")

    End Sub

    Protected Sub DataList1_ItemCommand(source As Object, e As DataListCommandEventArgs) Handles DataList1.ItemCommand

        'FIND THE MAIN IMAGE CONTROL 

        Dim mainimg As Image = DirectCast(e.Item.FindControl("Image1"), Image)

        'FIND IMAGE CONTROL BASED ON COMMAND NAME OF IMAGEBUTTON CONTROL.
        'FIRST WE FIND FOR "FIRST IMAGE BUTTON" AND COMMAND NAME IS 'F'.


        If e.CommandName.Equals("F") Then
            'DECLARE DATALISTITEM VARIABLE AND FIND ITEM INDEX OF SELECTED ITEM IN DATALIST.
            Dim item As DataListItem = DataList1.Items(e.Item.ItemIndex)
            'FIND CONTROL OF IMAGEBUTTON IN ITEM VARIABLE..
            Dim imgbtn As ImageButton = item.FindControl("ImageButton1")
            'SIMPLY SET THE IMAGEURL TO MAIN IMAGE URL.
            mainimg.ImageUrl = imgbtn.ImageUrl
        End If
        If e.CommandName.Equals("S") Then
            'DECLARE DATALISTITEM VARIABLE AND FIND ITEM INDEX OF SELECTED ITEM IN DATALIST.
            Dim item As DataListItem = DataList1.Items(e.Item.ItemIndex)
            'FIND CONTROL OF IMAGEBUTTON IN ITEM VARIABLE..
            Dim imgbtn As ImageButton = item.FindControl("ImageButton2")
            'SIMPLY SET THE IMAGEURL TO MAIN IMAGE URL.
            mainimg.ImageUrl = imgbtn.ImageUrl
        End If

    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bind()
        End If

    End Sub
    Protected Sub bind()
        cmd = New SqlCommand("select * from getImag ", con)
        con.Open()
        ad = New SqlDataAdapter(cmd)
        ad.Fill(ds)
        DataList1.DataSource = ds
        DataList1.DataSourceID = ""
        DataList1.DataBind()
        con.Close()
    End Sub
End Class
