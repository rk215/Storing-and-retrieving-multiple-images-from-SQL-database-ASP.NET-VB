
Partial Class Default2
    Inherits System.Web.UI.Page

    Protected Sub Unnamed1_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        'FIND THE MAIN IMAGE CONTROL 

        Dim mainimg As Image = DirectCast(e.Item.FindControl("Image1"), Image)

        'FIND IMAGE CONTROL BASED ON COMMAND NAME OF IMAGEBUTTON CONTROL.
        'FIRST WE FIND FOR "FIRST IMAGE BUTTON" AND COMMAND NAME IS 'F'.


        If e.CommandName.Equals("F") Then
            'DECLARE DATALISTITEM VARIABLE AND FIND ITEM INDEX OF SELECTED ITEM IN DATALIST.
            Dim item As RepeaterItem = repeater.Items(e.Item.ItemIndex)
            'FIND CONTROL OF IMAGEBUTTON IN ITEM VARIABLE..
            Dim imgbtn As ImageButton = item.FindControl("ImageButton1")
            'SIMPLY SET THE IMAGEURL TO MAIN IMAGE URL.
            mainimg.ImageUrl = imgbtn.ImageUrl
        End If
        If e.CommandName.Equals("S") Then
            'DECLARE DATALISTITEM VARIABLE AND FIND ITEM INDEX OF SELECTED ITEM IN DATALIST.
            Dim item As RepeaterItem = repeater.Items(e.Item.ItemIndex)
            'FIND CONTROL OF IMAGEBUTTON IN ITEM VARIABLE..
            Dim imgbtn As ImageButton = item.FindControl("ImageButton2")
            'SIMPLY SET THE IMAGEURL TO MAIN IMAGE URL.
            mainimg.ImageUrl = imgbtn.ImageUrl
        End If



    End Sub
End Class
