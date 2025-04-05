public class Package
{
    public int Id { get; set; }
    public string ResidentName { get; set; }
    public string ApartmentNumber { get; set; }
    public string Notes { get; set; }
    public bool PickedUp { get; set; }

    public void Display()
    {
        Console.WriteLine($"[{Id}] {ResidentName} | Apt: {ApartmentNumber}
         | Notes: {Notes} | Picked Up: {(PickedUp ? "Yes" : "No")}");
    }
}
