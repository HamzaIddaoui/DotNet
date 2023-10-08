using ProductWebapp.Models;

namespace ProductWebapp.Command
{
    public class AddToCart : Command
    {
        public Product product { get; set; }
        public AddToCart(Product newProduct) {
            product = newProduct;
        }
        public override void Execute()
        {
            Receiver receiver = Receiver.Instance();
            receiver.addToCart(product);
        }

        public override void Unexecute()
        {
            Receiver receiver = Receiver.Instance();
            receiver.removeFromCart(product);
        }
    }
}
