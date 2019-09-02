import java.util.Scanner;

public class Birthday {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double lenght = Integer.parseInt(scanner.nextLine());
        double wight = Integer.parseInt(scanner.nextLine());
        double height = Integer.parseInt(scanner.nextLine());
        double percentTaken = Double.parseDouble(scanner.nextLine());

        double volume = lenght * wight * height;
        double litres = volume * 0.001;
        double taken = percentTaken * 0.01;
        double water = litres * (1 - taken);

        System.out.printf("%.3f", water);
    }
}
