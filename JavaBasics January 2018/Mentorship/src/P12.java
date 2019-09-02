import java.util.Scanner;

public class P12 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double usdtobgn = 1.79549;
        double eurtobgn = 1.95583;
        double gbptobgn = 2.53405;

        double amount = Double.parseDouble(scanner.nextLine());
        String currencytoconvert = scanner.nextLine();
        String outputcurrency = scanner.nextLine();
        double result = 0.0;

        if ("BGN".equalsIgnoreCase(currencytoconvert)) {
            result = amount;
        } else if ("USD".equalsIgnoreCase(currencytoconvert)) {
            result = amount * usdtobgn;
        } else if ("EUR".equalsIgnoreCase(currencytoconvert)) {
            result = amount * eurtobgn;
        } else if ("GBP".equalsIgnoreCase(currencytoconvert)) {
            result = amount * gbptobgn;
        }

        if ("USD".equalsIgnoreCase(outputcurrency)) {
            result = result / usdtobgn;
        } else if ("EUR".equalsIgnoreCase(outputcurrency)) {
            result = result / eurtobgn;
        } else if ("GBP".equalsIgnoreCase(outputcurrency)) {
            result = result / gbptobgn;
        }
        System.out.printf("%.2f %s", result, outputcurrency);
    }
}