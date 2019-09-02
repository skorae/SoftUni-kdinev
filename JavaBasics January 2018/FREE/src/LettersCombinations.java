import java.util.Scanner;

public class LettersCombinations {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        char startLetter = scanner.nextLine().charAt(0);
        char endLetter = scanner.nextLine().charAt(0);
        char escapeLetter = scanner.nextLine().charAt(0);
        int counter = 0;

        for (int i = startLetter; i <= endLetter; i++) {
            if (i != escapeLetter) {
                for (int j = startLetter; j <= endLetter; j++) {
                    if (j != escapeLetter) {
                        for (int k = startLetter; k <= endLetter; k++) {
                            if (k != escapeLetter){
                                String str = "" + i + j + k;
                                System.out.println(str + " ");
                                counter++;
                            }
                        }
                    }
                }
            }
        }
    }
}
