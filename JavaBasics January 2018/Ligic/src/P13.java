import java.util.Scanner;

public class P13 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String type = scanner.nextLine();
        double a = Double.parseDouble(scanner.nextLine());

        if (type.equals("square")){
            double result = a * a;
            System.out.printf("%.3f", result);
        }else if (type.equals("rectangle")){
            double b = Double.parseDouble(scanner.nextLine());
            double result = a * b;
            System.out.printf("%.3f", result);
        } else if (type.equals("circle")) {
            double result = Math.PI * a * a;
            System.out.printf("%.3f", result);
        }else if (type.equals("triangle")){
            double  h = Double.parseDouble(scanner.nextLine());
            double result = a * h / 2;
            System.out.printf("%.3f", result);;

        }

    }
}
