using Microsoft.AspNetCore.Mvc;
using TdtLab5BT.Models;

namespace TdtLab5BT.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>();

        private List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Điện thoại"
                },
                new Category
                {
                    Id = 2,
                    Name = "Laptop"
                },
                new Category
                {
                    Id = 3,
                    Name = "Phụ kiện"
                }
            };
        }

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = GetCategories();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            ViewBag.Categories = GetCategories();

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            if (product.ImageFile == null ||
                product.ImageFile.Length == 0)
            {
                ModelState.AddModelError(
                    "ImageFile",
                    "Vui lòng chọn ảnh sản phẩm."
                );

                return View(product);
            }

            string[] allowedExtensions =
            {
                ".jpg",
                ".jpeg",
                ".png",
                ".gif",
                ".webp"
            };

            string extension =
                Path.GetExtension(
                    product.ImageFile.FileName
                ).ToLowerInvariant();

            if (!allowedExtensions.Contains(extension))
            {
                ModelState.AddModelError(
                    "ImageFile",
                    "Chỉ được chọn file ảnh JPG, JPEG, PNG, GIF hoặc WEBP."
                );

                return View(product);
            }

            const long maxFileSize = 5 * 1024 * 1024;

            if (product.ImageFile.Length > maxFileSize)
            {
                ModelState.AddModelError(
                    "ImageFile",
                    "Dung lượng ảnh không được vượt quá 5 MB."
                );

                return View(product);
            }

            string fileName =
                Guid.NewGuid().ToString() + extension;

            string uploadFolder =
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "products"
                );

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            string filePath =
                Path.Combine(
                    uploadFolder,
                    fileName
                );

            using (var stream =
                   new FileStream(
                       filePath,
                       FileMode.Create))
            {
                await product.ImageFile.CopyToAsync(stream);
            }

            product.Image = fileName;

            product.Id =
                products.Count == 0
                ? 1
                : products.Max(x => x.Id) + 1;

            products.Add(product);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var product =
                products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Categories = GetCategories();

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            ViewBag.Categories = GetCategories();

            var existingProduct =
                products.FirstOrDefault(x => x.Id == id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            if (product.ImageFile == null)
            {
                ModelState.Remove(nameof(Product.ImageFile));
            }

            if (!ModelState.IsValid)
            {
                product.Image = existingProduct.Image;
                return View(product);
            }

            if (product.ImageFile != null &&
                product.ImageFile.Length > 0)
            {
                string[] allowedExtensions =
                {
                    ".jpg",
                    ".jpeg",
                    ".png",
                    ".gif",
                    ".webp"
                };

                string extension =
                    Path.GetExtension(
                        product.ImageFile.FileName
                    ).ToLowerInvariant();

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError(
                        "ImageFile",
                        "Chỉ được chọn file ảnh JPG, JPEG, PNG, GIF hoặc WEBP."
                    );

                    product.Image = existingProduct.Image;

                    return View(product);
                }

                const long maxFileSize = 5 * 1024 * 1024;

                if (product.ImageFile.Length > maxFileSize)
                {
                    ModelState.AddModelError(
                        "ImageFile",
                        "Dung lượng ảnh không được vượt quá 5 MB."
                    );

                    product.Image = existingProduct.Image;

                    return View(product);
                }

                string uploadFolder =
                    Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        "products"
                    );

                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                string fileName =
                    Guid.NewGuid().ToString() + extension;

                string filePath =
                    Path.Combine(
                        uploadFolder,
                        fileName
                    );

                using (var stream =
                       new FileStream(
                           filePath,
                           FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(stream);
                }

                string oldImage = existingProduct.Image;

                existingProduct.Image = fileName;

                if (!string.IsNullOrEmpty(oldImage))
                {
                    string oldImagePath =
                        Path.Combine(
                            uploadFolder,
                            oldImage
                        );

                    try
                    {
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    catch (IOException)
                    {
                    }
                }
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.SalePrice = product.SalePrice;
            existingProduct.Description = product.Description;
            existingProduct.CategoryId = product.CategoryId;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var product =
                products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product =
                products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(product.Image))
            {
                string imagePath =
                    Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        "products",
                        product.Image
                    );

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            products.Remove(product);

            return RedirectToAction(nameof(Index));
        }
    }
}