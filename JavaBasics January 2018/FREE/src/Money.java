import java.util.Scanner;

public class Money {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int bitCoin = Integer.parseInt(scanner.nextLine());
        double cIoan = Double.parseDouble(scanner.nextLine());
        double commision = Double.parseDouble(scanner.nextLine());

        double bitCoinPrice = bitCoin * 1168;
        double cIoanPrice = (cIoan * 0.15) * 1.76;
        double totalInEUR = (bitCoinPrice + cIoanPrice) / 1.95;
        double total = totalInEUR - (totalInEUR * (commision / 100));

        System.out.printf("%.2f", total);
    }
}
