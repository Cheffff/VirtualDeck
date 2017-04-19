using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public int calculateAITurn(Board board) // Ici on a un exemple d'implémentation de mon ia random qui utilise ma fonction AITurn();
    {
        int randPiece;
        int randSquare;
        Square selectedSquare;
        Piece selectedPiece;
        List<Square> hovered_squares = null;
        do // tant qu'on a pas réussi à récupérer une piece, on "rerandomise" la piece à sélectionner. Ici, on pourra se débarasser de cette boucle lorsqu'on implémentera la vrai ia; il ne faudra cependant pas oublier de vérifier le CHECK_MATE. 
        {  // J'ai fais cette boucle car il pouvait arriver que la pièce sélectionnée ait déjà été bouffée
            if (board.black_ai)
            {
                randPiece = UnityEngine.Random.Range(board.firstBlackPieceIndex(), board.getPiecesCount());
                print("first black piece index = " + board.firstBlackPieceIndex());
            }
            else
            {
                randPiece = UnityEngine.Random.Range(0, board.firstBlackPieceIndex());
                print("first black piece index = " + board.firstBlackPieceIndex());
            }
            if (board.isCheckMate(1))
            {
                //                print("CHECK MATE");
                return (1);
            }
            selectedPiece = board.getPiece(randPiece);
        }
        while (selectedPiece == null);
        board.hoverValidSquares(selectedPiece);
        hovered_squares = board.getHoveredSquares();
        if (hovered_squares.Count > 1) // Ici on vérifie que le nombre de possibilité de déplacement de la pièce sélectionnée est au moins de 2 . Sinon, c'est que la pièce ne peut pas être ailleurs que là ou elle est !
        {
            randSquare = UnityEngine.Random.Range(2, hovered_squares.Count);
            if (randSquare >= hovered_squares.Count)
            {
//                print("ransSquare >= hovered_squares.Count || hovered_squares.Count == 1");
                return (0);
            }
            else
            {
 //               print(selectedPiece + " is at " + selectedPiece.cur_square.coor.pos + " and is to be moved to " + hovered_squares[randSquare].coor.pos);
  //              print(randSquare + " is the number of the square we are looking for");
                selectedSquare = hovered_squares[randSquare];
                return (board.AITurn(selectedPiece, selectedSquare));
            }
        }
        return (0);
    }
}
