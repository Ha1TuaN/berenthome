namespace TD.KCN.WebApi.Application.Catalog.Areas;

public class AreasByParentCodeSpec : Specification<Area>, ISingleResultSpecification<Area>
{
    public AreasByParentCodeSpec(string? parentCode) =>
         Query.Where(p => p.ParentCode == parentCode);

}