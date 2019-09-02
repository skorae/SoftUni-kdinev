import java.util.Scanner;

public class P08 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double value = Double.parseDouble(scanner.nextLine());
        String inputMetric = scanner.nextLine();
        String outputMetric = scanner.nextLine();

        if (inputMetric.equals("mm")) {
            value = value / 1000;
        } else if (inputMetric.equals("cm")) {
            value = value / 100;
        }else if (inputMetric.equals("mi")){
            value = value / 0.000621371192;
        } else if (inputMetric.equals("in")) {
            value = value / 39.3700787;
        } else if (inputMetric.equals("km")) {
            value = value / 0.001;
        } else if (inputMetric.equals("ft")) {
            value = value / 3.2808399;
        } else if (inputMetric.equals("yd")) {
            value = value / 1.0936133;
        }

        if (outputMetric.equals("mm")) {
            value = value * 1000;
        } else if (outputMetric.equals("cm")) {
            value = value * 100;
        } else if (outputMetric.equals("in")) {
            value = value * 39.3700787;
        }else if (outputMetric.equals("mi")){
            value = value * 0.000621371192;
        } else if (outputMetric.equals("km")) {
            value = value * 0.001;
        } else if (outputMetric.equals("ft")) {
            value = value * 3.2808399;
        } else if (outputMetric.equals("yd")) {
            value = value * 1.0936133;
        }

        System.out.printf("%.8f", value);
    }
}