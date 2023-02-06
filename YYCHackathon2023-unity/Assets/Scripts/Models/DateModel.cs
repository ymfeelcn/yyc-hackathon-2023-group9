using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class DateModel
{
    public int id;
    public string name;
    public string describtion;
    public string url;
    public string eventDate;
    public bool hasEvent;
}

[Serializable]
public class DateList
{
    public List<DateModel> dates;
}
