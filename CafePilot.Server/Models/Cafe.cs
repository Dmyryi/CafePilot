namespace CafePilot.Server.Models
{
    public class Cafe
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public Guid CityId {  get; set; }
        public string Street { get; set; }
        public string Geolat {  get; set; }
        public string Geolon {  get; set; }
        public Foto FotoCafe { get; set; }
        public string PhoneNumber {  get; set; }
        public TimeSpan StartWork { get; set; }
        public TimeSpan EndWork { get; set; }
        public double Rating {  get; set; }
        public int WaitingTime {  get; set; }
        public int IsOpen {  get; set; }
        public string IsOpenDescription {  get; set; }
    }
}
