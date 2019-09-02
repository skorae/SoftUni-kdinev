import java.util.Scanner;

public class Uchebna_Zala {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double w =Double.parseDouble(scanner.nextLine());
        double h =Double.parseDouble(scanner.nextLine());

        double wight = h * 100 - 100;
        double lenght = w * 100;

        double row = Math.floor(wight / 70);
        double column = Math.floor(lenght / 120);

        double seats = row * column - 3;

        System.out.println(seats);


    }
}
