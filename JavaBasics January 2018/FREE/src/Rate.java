import java.util.Scanner;

public class Rate {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double price = Double.parseDouble(scanner.nextLine());
        int period = Integer.parseInt(scanner.nextLine());

        double simpleRateIncrease = 0;
        double complexRateIncrease = price;
        double simple = 0;
        double complex = 0;
        double diff = 0;
        String better = "";

        for (int i = 0; i < period; i++) {

            simpleRateIncrease += price * 0.03;
            complexRateIncrease = complexRateIncrease + (complexRateIncrease * 0.027);

        }

        simple = price + simpleRateIncrease;
        complex = complexRateIncrease;

        System.out.printf("Simple interest rate: %.2f lv.\n", simple);
        System.out.printf("Complex interest rate: %.2f lv.\n", complex);

        if (simple < complex) {
            diff = complex - simple;
            better = "complex";
        } else {
            diff = simple - complex;
            better = "simple";
        }
        System.out.printf("Choose a %s interest rate. You will win %.2f lv.", better, diff);
    }
}
