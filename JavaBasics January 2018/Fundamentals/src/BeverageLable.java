import java.text.DecimalFormat;
import java.util.Scanner;

public class BeverageLable {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String name = scanner.nextLine();
        int volume = Integer.parseInt(scanner.nextLine());
        int energy100 = Integer.parseInt(scanner.nextLine());
        double sugar100 = Double.parseDouble(scanner.nextLine());

        double allEnergy = volume * (energy100 / 100.0);
        double totalSugar = volume * (sugar100 / 100.0);

        DecimalFormat df = new DecimalFormat("#.#####");
        System.out.printf("%dml %s:\n", volume, name);
        System.out.printf("%fkcal, %fg sugars", df.format(allEnergy), df.format(totalSugar));




    }
}
