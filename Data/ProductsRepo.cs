using System;

namespace mvc.Data;

public class ProductsRepo
{
    public List<Product> products = new();
    public Product Add(Product product)
    {
        products.Add(product);
        return product;
    }

    public List<Product> GetAll()
    {
        return products;
    }

    public Product GetById(int id)
    {
        var product = products.Find(x=>x.Id==id)??new Product();
        return product;
    }

    public string Delete(int id)
    {
        products.RemoveAll(x=>x.Id==id);
        return "Deleted successfully!";
    }

    public void Edit(Product product)
    {
        var pr = products.Find(x=>x.Id==product.Id);
        pr.Name = product.Name;
        pr.Price = product.Price;
    }
}
