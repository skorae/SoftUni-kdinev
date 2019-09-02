import java.util.Scanner;

public class P01 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double SaTOb = Double.parseDouble(scanner.nextLine());
        double Vtruck = Double.parseDouble(scanner.nextLine());
        double speedDiff = Double.parseDouble(scanner.nextLine());

        double Ttruck = Math.ceil(SaTOb / Vtruck);
        double Vcar = Vtruck + (speedDiff * 3.600);
        double Tcar = Math.ceil(SaTOb / Vcar);

        System.out.printf("The truck arrived after %.0f hours\n", Ttruck);
        System.out.printf("The car arrived after %.0f hours", Tcar);
    }
}
