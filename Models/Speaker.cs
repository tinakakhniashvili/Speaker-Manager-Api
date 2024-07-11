using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeakerManagerApi.Models
{
    public class Speaker
    {
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Role { get; set; }
    public string ProfilePicture { get; set; }
    }   

}