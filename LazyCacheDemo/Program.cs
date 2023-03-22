using LazyCacheDemo;

// create handler for product
ProductHandler productHandler = new();
// initialize dummy data
productHandler.InitReset();

// get data from cache
Product product1 = productHandler.GetProduct("product-06");
Product product2 = productHandler.GetProduct("product-01");

Console.WriteLine("Product Name : " + product1.Name + "    Product Price : " + product1.Price);
Console.WriteLine("Product Name : " + product2.Name + "    Product Price : " + product2.Price);