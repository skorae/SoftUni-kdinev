import java.util.Scanner;

public class Exercise {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int bitCoinCount = Integer.parseInt(scanner.nextLine());
        double CIoanCount = Double.parseDouble(scanner.nextLine());
        double commicion = Double.parseDouble(scanner.nextLine());

        double bitCoin = 1168; ///BGN
        double CIoan = 0.15; /// USD
        double USD = 1.76; /// BGN
        double EUR = 1.95; /// BGN

        double moneyBitcoin = bitCoinCount * bitCoin;
        double moneyCIoan = (CIoanCount * CIoan) * USD;
        double totalBGN = (moneyBitcoin + moneyCIoan) / EUR;
        double total = totalBGN - (totalBGN * commicion / 100);

        System.out.printf("%.2f", total);




    }
}

