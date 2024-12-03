using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RegisterModelResponse
{
    public bool status;
    public Account data;
}

[Serializable]
public class Account
{
    public int Id;
    public string Email;
    public string Password;
    public string Name;
    public DateTime Created_At;
    public DateTime Updated_At;
}
