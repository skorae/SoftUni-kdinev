import java.util.Scanner;

public class Fishland {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double skumriqKGcena = Double.parseDouble(scanner.nextLine());
        double cacaKGcena = Double.parseDouble(scanner.nextLine());
        double palamudKGteglo = Double.parseDouble(scanner.nextLine());
        double safridKGteglo = Double.parseDouble(scanner.nextLine());
        int midiKGteglo = Integer.parseInt(scanner.nextLine());

        double palamud = palamudKGteglo * (skumriqKGcena + (skumriqKGcena * 0.6));
        double safrid = safridKGteglo * (cacaKGcena + (cacaKGcena * 0.8));
        double midi = midiKGteglo * 1.0 * 7.50;
        double total = palamud + safrid + midi;

        System.out.printf("%.2f", total);
    }
}
