using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DBBookRead : MonoBehaviour
{
    public int id=-1;
    public Text view,search,download;

    string giantString;

    public string[] registeredusers;
    public string[] bookids = new string[100];
    public string[] weblinks = new string[100];
    public string[] downloadlinks = new string[100];
    public string[] recommendedbooks = new string[100];
    public string[] descriptions = new string[100];
    public string[] prerequisites = new string[100];
    public string[] bookcontents = new string[100];

    IEnumerator Start()
    {
        WWW users = new WWW("https://bookreaderxr.000webhostapp.com/readBook.php");
        yield return users;

        giantString = users.text;

        registeredusers = giantString.Split("|;|");

        for (int i = 0; i < registeredusers.Length - 1; i++)
        {
            bookids[i] = registeredusers[i].Substring(registeredusers[i].IndexOf("BookId") + 7);
            bookids[i] = bookids[i].Remove(bookids[i].IndexOf("|WebLink"));

            weblinks[i] = registeredusers[i].Substring(registeredusers[i].IndexOf("WebLink") + 8);
            weblinks[i] = weblinks[i].Remove(weblinks[i].IndexOf("|DownloadLink"));

            downloadlinks[i] = registeredusers[i].Substring(registeredusers[i].IndexOf("DownloadLink") + 13);
            downloadlinks[i] = downloadlinks[i].Remove(downloadlinks[i].IndexOf("RecommendedBooks"));

            recommendedbooks[i] = registeredusers[i].Substring(registeredusers[i].IndexOf("RecommendedBooks") + 17);
            recommendedbooks[i] = recommendedbooks[i].Remove(recommendedbooks[i].IndexOf("Description"));

            descriptions[i] = registeredusers[i].Substring(registeredusers[i].IndexOf("Description") + 12);
            descriptions[i] = descriptions[i].Remove(descriptions[i].IndexOf("Prerequisite"));

            prerequisites[i] = registeredusers[i].Substring(registeredusers[i].IndexOf("Prerequisite") + 13);
            prerequisites[i] = prerequisites[i].Remove(prerequisites[i].IndexOf("BookContent"));

            bookcontents[i] = registeredusers[i].Substring(registeredusers[i].IndexOf("BookContent") + 12);
            //bookcontents[i] = bookcontents[i].Remove(bookcontents[i].IndexOf("|;"));

        }

    }
    public void bookId(int id)
    {
        this.id = id;
        if (id == -1)
            return;
        view.text = "Scanned Successfully";
        search.text = weblinks[id];
        download.text = downloadlinks[id];
    }
   
    public  void showOnScreen(int val)
    {
        if(id==-1)
        {
            view.text = "Book not Scanned";
        }
        if (val == 0)
            view.text = "";
        else if (val == 1)
            view.text = FormatData(prerequisites[id]);
        else if (val == 2)
            view.text = FormatData(recommendedbooks[id]);
        else if (val == 3)
            view.text = FormatData(bookcontents[id]);
        else if (val == 4)
            view.text = FormatData(descriptions[id]); 
    }
    
    private string FormatData(string data)
    {
        Debug.Log(data);
        return data;
    }

}
