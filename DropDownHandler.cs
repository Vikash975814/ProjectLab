using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropDownHandler : MonoBehaviour
{
    public Dropdown book;
    public DBBookRead readBook;
    int val = 0;
    public void Start()
    {
        book.onValueChanged.AddListener(delegate
        {
            bookvalueChangedHappened(book);
        });
        
    }

    
    public void bookvalueChangedHappened(Dropdown choose )
    {
        this.val = (int)choose.value;
        Debug.Log("Hello "+choose.value+" "+val);
        readBook.showOnScreen(val);
    }
}
