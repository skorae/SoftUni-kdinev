import java.util.Scanner;

public class P_UsdToBgn {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        double usd = Double.parseDouble(scanner.nextLine());

        double lev = usd * 1.79549;

        System.out.printf("%.2f");
    }
}
