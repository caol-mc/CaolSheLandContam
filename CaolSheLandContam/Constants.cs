using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaolSheLandContam
{
    class Constants
    {
        public static string ASSUREURL = "https://stirling.she-development.net/automation";
        public static string USERNAME = "CaolM";
        public static string PASSWORD = "SHE334";
        public static string ASSUREHOME = "she-login-wrapper";
        public static string LOGIN = "login";
        public static string SAVEANDCLOSE = "save & close";
        public static string TRANSLATE = "translate(normalize-space(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ*:', 'abcdefghijklmnopqrstuvwxyz')";
        public static string TRANSLATEVALUE = "translate(normalize-space(@title), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ*:', 'abcdefghijklmnopqrstuvwxyz')";
        public static string PREFIX = "//div['she-login-wrapper']/descendant::";
        public static string ITEMBOX = "//div[contains(@class, 'item-box')]/descendant::";

        public static By BYLOGINPAGE = By.XPath("//div[contains(@class, 'she-login')]");
        public static By BYHOMEPAGE = By.XPath("//div[@class='headercontainer she-userrole-Users']");

    }
}
