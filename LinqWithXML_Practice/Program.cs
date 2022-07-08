using System.Xml.Linq;

string studentsXML =
    @"<Students>
        <Student>
            <Name>Tony</Name>
            <Age>21</Age>
            <University>SC </University>
         </Student>

         <Student>
            <Name>Harry</Name>
            <Age>52</Age>
            <University>NC </University>
         </Student>

          <Student>
            <Name>Mike</Name>
            <Age>35</Age>
            <University>FL</University>
         </Student>
      </Students>";

XDocument studentXdoc = new();
studentXdoc = XDocument.Parse(studentsXML);

//The below code grabs the xml above and stores the descendants by selecting and storing new entries
//in students. The null coalescing operator takes care of the possible null values in the elements

var students = from student in studentXdoc.Descendants("Student")
               select new
               {

                   Name = student.Element("Name")?.Value,
                   Age =  student.Element("Age")?.Value,
                   University = student.Element("University")?.Value
               };






var studentsByAge = from student in students
                    orderby student.Age
                    select student;

foreach (var student in studentsByAge)
{
   
    Console.WriteLine($"{student.Name}, {student.Age}");
}

foreach(var s in studentsByAge)
{
    
    Console.WriteLine($"{s.Age} is the age.");
}