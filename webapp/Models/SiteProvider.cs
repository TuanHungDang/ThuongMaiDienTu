namespace webapp.Models;
public class SiteProvider : BaseProvider
{
    public SiteProvider(IConfiguration conf) : base(conf){
    }
    CategoryRepository category;
    public CategoryRepository Category => category ??= new(Connection);

    BrandRepository brand;
    public BrandRepository Brand => brand ??= new(Connection);

    ProductRepository product;
    public ProductRepository Product => product ??= new(Connection);

}