import java.util.Scanner;

public class Lutenitsa {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double tomatoKilos = Double.parseDouble(scanner.nextLine());
        int xBox = Integer.parseInt(scanner.nextLine());
        int yJar = Integer.parseInt(scanner.nextLine());
        double diffBoxes = 0;
        double diffJars = 0;

        double allLutenitsa = tomatoKilos / 5;
        System.out.printf("Total lutenica: %.0f kilograms.\n", Math.floor(allLutenitsa));

        double jarsMade = allLutenitsa / 0.535;
        double boxesMade = jarsMade / yJar;
        double allXjars = yJar * xBox;

        if (xBox > boxesMade) {
            diffBoxes = Math.floor(xBox - boxesMade);
            diffJars = Math.floor(allXjars - jarsMade);
            System.out.printf("%.0f more boxes needed.\n%.0f more jars needed.", diffBoxes, diffJars);
        } else {
            diffBoxes = Math.floor(boxesMade - xBox);
            diffJars = Math.floor(jarsMade - allXjars);
            System.out.printf("%.0f boxes left.\n%.0f jars left.", diffBoxes, diffJars);
        }
    }
}
