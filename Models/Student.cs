using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cw2.Models
{
    public class Student
    {
        [XmlAttribute(attributeName: "email")]
        public string Email { get; set; }
        [XmlElement(elementName: "fname")]
        public string Imie { get; set; }

        //propfull + tabx2

        private string _nazwisko;
        public string Nazwisko
        {
            get { return _nazwisko; }
            set
            {
                if (value == null) throw new ArgumentException();
                _nazwisko = value;
            }
        }

    }
}
