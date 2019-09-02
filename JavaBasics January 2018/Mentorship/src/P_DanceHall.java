import java.util.Scanner;

public class P_DanceHall {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int dancerArea = 40;
        int freespace = 7000;

        double L = Double.parseDouble(scanner.nextLine());
        double W = Double.parseDouble(scanner.nextLine());
        double A = Double.parseDouble(scanner.nextLine());

        double Shall = (L * 100) * (W * 100);
        double SA = A * 100 * A * 100;
        double Sbench = Shall / 10.0;
        double SfreeSpace = Shall - SA - Sbench;

        int Hall = (int)(SfreeSpace / (dancerArea + freespace));

        System.out.println(Hall);
    }
}
