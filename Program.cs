using System;
using System.IO;

static class IntExtentions{
    
    public static int GetNegative(this int source){
      if (source > 0){
            return source*(-1);
        }
        return source;  
    }
}

class HW_03{

    
    abstract class Delivery 
    {
        public string Address;
        public DateTime ExpectedDate;

        public virtual void GetDeliveryDate(){
            Console.WriteLine($"Доставка товара ожидается {ExpectedDate}");
        }
    }
    class HomeDelivery: Delivery {  
        public string TimeRange;
        public override void GetDeliveryDate()
        {
            base.GetDeliveryDate();
        }

        }
    class PickPointDelivery: Delivery {  
        static string WorkingHours;
        public override void GetDeliveryDate()
        {
            base.GetDeliveryDate();
            Console.WriteLine($"Время работы ПВЗ: {WorkingHours}");
        }

        }
    class ShopDelivery: Delivery {  
        static string WorkingHours;
        public override void GetDeliveryDate()
        {
            base.GetDeliveryDate();
            Console.WriteLine($"Время работы магазина: {WorkingHours}");
        }
        }
    abstract class Photo{
        private protected int id;
        public int Id {get{return id;}}
        public string Link;
    }
    class ProfilePicture:Photo{
        public ProfilePicture(int _id, string _link){
            id = _id;
            Link = _link;
        }
    } 
    class ProductPicture:Photo{
        public ProductPicture(int _id, string _link){
            id = _id;
            Link = _link;
        }
    } 
    class UserPicture:Photo{
        public UserPicture(int _id, string _link){
            id = _id;
            Link = _link;
        }
    } 
    class Persone{
        private protected int id;
        public int Id {get{return id;}}
        public string Name;
        public string Phone;
        public string Email;
        public ProfilePicture Picture;
        public ShoppingCart[] ShoppingCarts;
        public Order<Delivery>[] Orders;
        public int CurrentCart;
        public Persone(int _id, int _pictureId, string _pictureLink){
            id = _id;
            Picture = new ProfilePicture(_pictureId, _pictureLink);
        }
        public Persone(int _id, int _pictureId, string _pictureLink, ShoppingCart Cart){
            id = _id;
            Picture = new ProfilePicture(_pictureId, _pictureLink);
            ShoppingCarts.Append(Cart);
        }
    }
    class Specification{
        public string Name;
        public string Value;
    }
    class Review{
        public Persone User;
        public string Text;
        public UserPicture[] Pictures;     
    }
    class Product
    {
        private protected int id;
        public int Id {get{return id;}}
        public string Name;
        public string Description;
        public ProductPicture[] Pictures;
        public Specification[] SpetificationList;
        public Review[] Reviews;
        public int CountInCurrentCart;
        public Product(int _id){
            id = _id;
        }

    }
    
    class ShoppingCart{
        int number;
        public Product[] ListOfProduct;   
        public Product this[string name]{
            get{
                for (int i = 0; i < ListOfProduct.Length; i++){
                    if (ListOfProduct[i].Name == name){
                        return ListOfProduct[i];
                    }
                }
                return null;
                }
            }
        
        public static ShoppingCart operator + (ShoppingCart Cart1, ShoppingCart Cart2){
            ShoppingCart TempCart = new ShoppingCart();
            TempCart = Cart1;
            foreach (Product product in Cart2.ListOfProduct){
                TempCart.ListOfProduct.Append(product);
            }
            return TempCart;
        }
            
    }
    class Order <TDelivery> where TDelivery: Delivery 
    {  
        public TDelivery Delivery;
        private int Number;
        public string Description;
        public void DisplayAddress() 
        {
          Console.WriteLine(Delivery.Address);
        }
        public int ShoppingCartId;
        private DateTime date;
        public DateTime Date{get{return date;} // Свойство date доступно только для чтения 
        }

        public Order(){
            date = DateTime.Now;
        }

    }


    static void Main(){
        Console.WriteLine("Hello");
    }
}