import java.util.Scanner;

public class Bills {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int month = Integer.parseInt(scanner.nextLine());

        double water = 0;
        double internet = 0;
        double elecBill = 0;
        double other = 0;

        for (int i = 0; i < month; i++) {

            elecBill += Double.parseDouble(scanner.nextLine());
            water +=20;
            internet += 15;
            other = (elecBill + water + internet) * 1.20;
        }
        double average = (elecBill + water + internet+ other) / month;
        System.out.printf("Electricity: %.2f lv\n" +
                "Water: %.2f lv\n" +
                "Internet: %.2f lv\n" +
                "Other: %.2f lv\n" +
                "Average: %.2f lv", elecBill, water, internet,other, average);
    }
}
