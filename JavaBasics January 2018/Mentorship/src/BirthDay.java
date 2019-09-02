import java.util.Scanner;

public class BirthDay {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

      int a = Integer.parseInt(scanner.nextLine());
      int b = Integer.parseInt(scanner.nextLine());
      int c = Integer.parseInt(scanner.nextLine());
      double y = Double.parseDouble(scanner.nextLine());

      double volume = (a * b * c) * 0.001;
      double result = volume * (1 - (y * 0.01));

        System.out.println(result);

    }
}
