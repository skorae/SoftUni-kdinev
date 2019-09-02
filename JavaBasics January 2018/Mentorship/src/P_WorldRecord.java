import java.util.Scanner;

public class P_WorldRecord {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double record = Double.parseDouble(scanner.nextLine());
        double distance = Double.parseDouble(scanner.nextLine());
        double timePerMeter = Double.parseDouble(scanner.nextLine());

        double timeIvancho = distance * timePerMeter;

        timeIvancho += Math.floor(distance /15) * 12.5;

    }
}
