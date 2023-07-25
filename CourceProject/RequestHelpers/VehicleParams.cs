namespace CourceProject.RequestHelpers;

public class VehicleParams : PaginationParams
{
    public string OrderBy { get; set; }
    public string SearchTerm { get; set; }
    public string Manufacturers { get; set; }
    
}