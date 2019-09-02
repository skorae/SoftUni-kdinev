import java.util.Scanner;

public class P08 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String city = scanner.nextLine();
        double sales = Double.parseDouble(scanner.nextLine());
        double commission = 0;

        if (city.equals("Sofia")) {
            if (sales >= 0 && sales <= 500) {
                commission = 0.05;
            } else if (500 < sales && sales <= 1000) {
                commission = 0.07;
            } else if (1000 < sales && sales <= 10000) {
                commission = 0.08;
            } else if (sales > 10000) {
                commission = 0.12;
            } else {
                System.out.println("error");
            }
        } else if (city.equals("Varna")) {
            if (sales >= 0 && sales <= 500) {
                commission = 0.045;
            } else if (500 < sales && sales <= 1000) {
                commission = 0.075;
            } else if (1000 < sales && sales <= 10000) {
                commission = 0.1;
            } else if (sales > 10000) {
                commission = 0.13;
            } else {
                System.out.println("error");
            }

        } else if (city.equals("Plovdiv")) {
            if (sales >= 0 && sales <= 500) {
                commission = 0.055;
            } else if (500 < sales && sales <= 1000) {
                commission = 0.08;
            } else if (1000 < sales && sales <= 10000) {
                commission = 0.12;
            } else if (sales > 10000) {
                commission = 0.145;
            } else {
                System.out.println("error");
            }
        } else {
            System.out.println("error");
        }
        double total = sales * commission;
        System.out.printf("%.2f", total);
    }
}



