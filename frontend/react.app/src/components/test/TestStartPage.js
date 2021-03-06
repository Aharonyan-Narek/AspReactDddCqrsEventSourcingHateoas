import React, { useEffect } from "react";
import { connect } from "react-redux";
import { loadTestQuestions } from "../../redux/actions/testActions";
import PropTypes from "prop-types";
import QuestionsList from "./QuestionsList";

const TestStartPage = ({ loadTestQuestions, testQuestions }) => {

    useEffect(() => {
        loadTestQuestions().then(quest => {console.log(quest)});
    });

    return(
        <>
            <p>Questions</p>
            <QuestionsList testQuestions={testQuestions}/>
        </>
    );
};

TestStartPage.propTypes = {
    testQuestions: PropTypes.array.isRequired,
    loadTestQuestions: PropTypes.func.isRequired
};

function mapStateToProps(state) {
    return {
        testQuestions: state.testQuestions
    };
}

const mapDispatchToProps = {
    loadTestQuestions
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(TestStartPage);