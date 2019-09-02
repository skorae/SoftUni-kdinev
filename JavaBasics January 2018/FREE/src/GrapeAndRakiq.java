import java.util.Scanner;

public class GrapeAndRakiq {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double size = Double.parseDouble(scanner.nextLine());
        double grapesPerM = Double.parseDouble(scanner.nextLine());
        double brak = Double.parseDouble(scanner.nextLine());

        double allGrapes = (size * grapesPerM) - brak;

        double rakiq = ((allGrapes * 0.45) / 7.5) * 9.80;
        double grapesSale = (allGrapes * 0.55) * 1.50;

        System.out.printf("%.2f\n%.2f", rakiq, grapesSale);
    }
}
