using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DBRead : MonoBehaviour
{
    public Text status;
    public InputField inputUser, inputPass;
    string giantString;
    //bool takeausername = false;

    public string[] registeredusers;
    public string[] usernames = new string[100];
    public string[] passwords = new string[100];
    public string[] emails = new string[100];

    IEnumerator Start()
    {
        WWW users = new WWW("https://bookreaderxr.000webhostapp.com/read.php");
        yield return users;
        giantString = users.text;

        registeredusers = giantString.Split(";");

        for(int i = 0;i<registeredusers.Length-1;i++)
        {
            usernames[i] = registeredusers[i].Substring(registeredusers[i].IndexOf('U')+9);
            usernames[i] = usernames[i].Remove(usernames[i].IndexOf('|'));

            passwords[i] = registeredusers[i].Substring(registeredusers[i].IndexOf("Password") + 9);
            passwords[i] = passwords[i].Remove(passwords[i].IndexOf('|'));

            emails[i] = registeredusers[i].Substring(registeredusers[i].IndexOf("Email") + 6);
            emails[i] = emails[i].Remove(emails[i].IndexOf('|'));

        }
    }

    public void tryToLogin()
    {
        bool found = false;
        if(inputUser.text == ""|| inputPass.text == "") {
            status.text = "username/email or password can't be empty";
        }
        else
        {
            
            for (int i = 0; i < registeredusers.Length - 1; i++)
            {
                
                if (inputUser.text == emails[i] || inputUser.text == usernames[i])
                {
                    
                    if(inputPass.text == passwords[i])
                    {
                        status.text = "Success!";
                        SceneManager.LoadScene("HomePage");
                        
                    }
                    else
                    {
                        status.text = "Wrong password";
                    }
                    found = true;
                    break;
                }
            }
            if(!found)
            {
                status.text = "user not found!";
            }
        }
    } 
    
    /*
    public void trToRegister()
    {
        takeausername = false;
        if (regUser.text == "" || regPass.text == "" || regEmail.text == "")
            status.text = "Can't be empty";
        else
        {
            for(int i = 0; i < registeredusers.Length - 1; i++)
            {
                if(regUser.text == usernames[i])
                {
                    takeausername = true;
                    break;
                }
            }
            if(!takeausername && regUser.text!="Password")
            {
                status.text = "Registered Successfully";
                registerUser(regUser.text, regPass.text, regEmail.text);
            }
            else
            {
                status.text = "Username Already Taken";
            }
        }
        

    }
        public void registerUser(string username , string password , string email)
        {
            WWWForm form = new WWWForm();

            form.AddField("usernamePost", username);
            form.AddField("passwordPost", password);
            form.AddField("emailePost", email);

            WWW register = new WWW("http://localhost/insertUser.php", form);
        }
      */
    
}
