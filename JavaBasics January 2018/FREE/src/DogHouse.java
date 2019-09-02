import java.util.Scanner;

public class DogHouse {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double A = Double.parseDouble(scanner.nextLine());
        double B = Double.parseDouble(scanner.nextLine());

        double greenSides = (A * (A / 2)) * 2;
        double greenBack = ((A/2) * (A /2)) + (((A/2) * (B - A/2)) / 2);
        double greenFront = ((A/2) * (A /2) + (((A/2) * (B - A/2)) / 2)) - ((A/5) * (A /5));
        double redRoof = (A * (A /2)) * 2;
        double green = (greenBack + greenFront + greenSides) / 3;
        double red = redRoof / 5;

        System.out.printf("%.2f%n%.2f", green, red);

    }
}
