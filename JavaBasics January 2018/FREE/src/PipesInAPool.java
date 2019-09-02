import java.util.Scanner;

public class PipesInAPool {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int v = Integer.parseInt(scanner.nextLine());
        int p1 = Integer.parseInt(scanner.nextLine());
        int p2 = Integer.parseInt(scanner.nextLine());
        double h = Double.parseDouble(scanner.nextLine());

        double P1 = p1 * h;
        double P2 = p2 * h;
        double total = P1 + P2;

        if (total > v) {
            int overflow = (int) total - v;
            System.out.printf("For %f hours the pool overflows with %d liters.", h, overflow);
        }else if (total <= v){
            int filled = (int)((total * 100) / v);
            int filledP1 = (int)((P1 * 100) / total);
            int filledP2 = (int)((P2 * 100) / total);
            System.out.printf("The pool is %d%% full. Pipe 1: %d%%. Pipe 2: %d%%.", filled, filledP1, filledP2);
        }

    }
}
