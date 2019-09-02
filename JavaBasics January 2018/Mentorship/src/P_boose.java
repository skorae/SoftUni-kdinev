import java.util.Scanner;

public class P_boose {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double whiskeyPrice = Double.parseDouble(scanner.nextLine());
        double BeerLitter = Double.parseDouble(scanner.nextLine());
        double WineLitter = Double.parseDouble(scanner.nextLine());
        double RakiqLitter = Double.parseDouble(scanner.nextLine());
        double whiskeyLitters = Double.parseDouble(scanner.nextLine());

        double RakiqPrice = whiskeyPrice / 2; //25
        double WinePrice = RakiqPrice - (RakiqPrice * 0.4);
        double BeerPrice = RakiqPrice - (RakiqPrice * 0.8);

        double Whiskey = whiskeyLitters * whiskeyPrice;
        double Rakiq = RakiqLitter * RakiqPrice;
        double Beer = BeerLitter * BeerPrice;
        double Wine = WineLitter * WinePrice;

        double BooseMoneyNeeded = Whiskey + Rakiq + Beer + Wine;

        System.out.printf("%.2f", BooseMoneyNeeded);


    }
}
