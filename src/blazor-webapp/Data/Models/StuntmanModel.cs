namespace Stuntman.Web.Data.Models;

public class StuntmanModel
{
    public StuntmanModel(int userId)
    {
        UserId = userId;
    }

    public StuntmanModel() { }

    public int Id { get; set; }
    public int UserId { get; set; }
    public string ExternalId { get; set; }
    public string GivenName { get; set; }
    public string FamilyName { get; set; }
    public string DisplayName { get; set; }
    public string UserName { get; set; }
    public string Initials { get; set; }
    public string PersonalEmailAddress { get; set; }
    public string PersonalPhoneNumber { get; set; }
    public string BusinessEmailAddress { get; set; }
    public string BusinessPhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public string BirthPlace { get; set; }
    public string Language { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public int HouseNumber { get; set; }
    public string ZipCode { get; set; }
    public int IsActive { get; set; }
    public string UserGuid { get; set; }
    public string Company { get; set; }
}
